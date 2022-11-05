using System.Text;
using System.Xml;
using System.IO.Compression;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Text.RegularExpressions;
using System.IO;

namespace EpubHandler
{

    public static class EPUBParse
    {
        // Regex Patterns
        private static readonly string _pagePattern = @"p\d\d\d\";
        private static readonly string _chapterPattern1 = @"c\d\d\d";
        private static readonly string _chapterPattern2 = @"-\d\d\d";
        private static readonly string _volumePattern = @"v\d\d";
        //
        // Fields
        //
        private static EPUBSettings _settings = new();

        private static List<string> _imageRef = new();

        private static XmlWriterSettings _xmlSettings = new XmlWriterSettings()
        {
            Indent = true,
            IndentChars = ("   "),
            CloseOutput = true
        };
        //
        // Public Methods
        //
        public static void BuildEpub(EPUBSettings settings)
        {
            _settings = settings;
            string workingDirectory = settings.OutputDirectory + "/work";

            DirectoryStructureCreate(workingDirectory);
            CreateMimeType(workingDirectory);
            CreateContainerFile(workingDirectory, _xmlSettings);
            FormatAndSaveImages(workingDirectory, settings.ContentSource);
            CreateContentFile(workingDirectory, settings);
            AddCSS(workingDirectory);
            CreateTocFile(workingDirectory, settings);

            FolderToEpub(settings);

        }

        public static void RenameFilesInFolder(string directory, EPUBSettings settings)
        {
            string[] folder = Directory.GetFiles(directory);

            for (int i = 0; i < folder.Length; i++)
            {
                string name = Path.GetFileName(folder[i]).Replace(" ", "");
                string extension = Path.GetExtension(folder[i]);

                string chapter = "";
                if (Regex.Match(name, _chapterPattern1).Success)
                {
                    chapter = Regex.Match(name, _chapterPattern1).Value;
                }
                else
                {
                    chapter = Regex.Match(name, _chapterPattern2).Value;
                }



                chapter = chapter.Replace("-", "c");
                string outName = settings.Title + "-" + chapter + "-p" + (i +1).ToString("000") + extension;


                File.Move(folder[i], Path.GetDirectoryName(folder[i]) + "/" + outName);
            }
        }

        public static void RenameFoldersInFolder(string directory, EPUBSettings settings)
        {
            string[] folder = Directory.GetDirectories(directory);

            for (int i = 0; i < folder.Length; i++)
            {
                string volume = i.ToString("000");
                string name = settings.Title + "-(v" + volume + ")";

                Directory.Move(folder[i], directory + "/" + name);
            }
        }

        public static void FolderToEpub(EPUBSettings settings)
        {
            ZipFile.CreateFromDirectory(settings.OutputDirectory + "/work", settings.OutputDirectory + "/" + settings.Title + ".epub");
            Directory.Delete(settings.OutputDirectory + "/work", true);
        }

        public static void FolderToEpub(string directory)
        {
            ZipFile.CreateFromDirectory(directory, directory + ".epub");
        }

        public static void FolderToEpub(string fromDirectory, string toDirectory)
        {
            ZipFile.CreateFromDirectory(fromDirectory, toDirectory + ".epub");
        }
        //
        // Private Main Methods
        //
        private static void DirectoryStructureCreate(string directory)
        {
            var MainDirectory = Directory.CreateDirectory(directory);
            CreateMimeType(directory);
            MainDirectory.CreateSubdirectory("META-INF");
            MainDirectory.CreateSubdirectory("OEBPS");


        }

        private static void CreateContainerFile(string directory, XmlWriterSettings settings)
        {
            XmlWriter writer = XmlWriter.Create(directory + "/META-INF/" + "container.xml", settings);

            writer.WriteStartElement("container", "urn:oasis:names:tc:opendocument:xmlns:container");
            writer.WriteAttributeString("version", "1.0");

            writer.WriteStartElement("rootfiles");

            writer.WriteStartElement("rootfile");
            writer.WriteAttributeString("full-path", "OEBPS/content.opf");
            writer.WriteAttributeString("media-type", "application/oebps-package+xml");

            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }

        /// <summary>
        /// Defines the Content
        /// Metadata dc: rights, identifier, creator, title, language, subject, date, event, source, !!Cover
        /// Manifest: define all media sources as: (item) href="link to media/html source" id="html dom id" media-type="image/jpeg or application/xhtml+xxml" (/item)
        /// Spine: Media chronology (itemref) idref="id to item manifest" linear="yes/no"
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="settings"></param>
        private static void CreateContentFile(string directory, EPUBSettings settings)
        {
            List<string> contents = Directory.GetFiles(directory + "/OEBPS").ToList();

            List<string> idImg = new();

            XmlWriter writer = XmlWriter.Create(directory + "/OEBPS/" + "content.opf", _xmlSettings);
            // Main package container
            // package Start
            writer.WriteStartElement("package", "http://www.idpf.org/2007/opf");
            writer.WriteAttributeString("xmlns", "opf", null, "http://www.idpf.org/2007/opf");
            writer.WriteAttributeString("xmlns", "dc", null, "http://purl.org/dc/elements/1.1/");
            writer.WriteAttributeString("xmlns", "dcterms", null, "http://purl.org/dc/terms/");
            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("version", "2.0");
            writer.WriteAttributeString("unique-identifier", "id");

            // Metadata Start
            writer.WriteStartElement("metadata");

            // Define Cover
            // Meta Start
            writer.WriteStartElement("meta");
            writer.WriteAttributeString("name", "cover");

            string? coverFile = contents.Find(fileName =>
            {
                return fileName.Contains("p000[");
            });
            writer.WriteAttributeString("content", Path.GetFileNameWithoutExtension(coverFile) + ".html");

            writer.WriteEndElement(); // End meta:Cover
            writer.WriteEndElement(); // End Metadata

            // Begin Manifest
            writer.WriteStartElement("manifest");

            // Item template = href, id, media-type
            int fileCount = 0;
            string coverHref = "";


            foreach (string img in contents)
            {
                string filename = Path.GetFileName(img);
                if (Path.GetExtension(img) == ".jpeg")
                {
                    string id = Path.GetFileNameWithoutExtension(img);
                    idImg.Add(id);

                    writer.WriteStartElement("item");
                    writer.WriteAttributeString("href", Path.GetFileName(img));
                    writer.WriteAttributeString("id", id);
                    writer.WriteAttributeString("media-type", "image/jpeg");
                    writer.WriteEndElement();


                    if (img == coverFile)
                    {
                        CreateHtmlFile(directory, filename, id, "Cover");
                        writer.WriteStartElement("item");
                        writer.WriteAttributeString("href", id + ".html");
                        writer.WriteAttributeString("id", "item" + fileCount);
                        writer.WriteAttributeString("media-type", "application/xhtml+xml");
                        writer.WriteEndElement();

                        coverHref = id + ".html";

                        fileCount++;
                    }
                    else
                    {
                        CreateHtmlFile(directory, filename, id, settings.Title);
                        writer.WriteStartElement("item");
                        writer.WriteAttributeString("href", id + ".html");
                        writer.WriteAttributeString("id", "item" + fileCount);
                        writer.WriteAttributeString("media-type", "application/xhtml+xml");
                        writer.WriteEndElement();
                        fileCount++;
                    }
                }
            }

            // reference to contents html file
            writer.WriteStartElement("item");
            writer.WriteAttributeString("href", "contents.html" + "#contentStart");
            writer.WriteAttributeString("id", "contents");
            writer.WriteAttributeString("media-type", "application/xhtml+xml");
            writer.WriteEndElement();

            // css ref
            writer.WriteStartElement("item");
            writer.WriteAttributeString("href", "pgepub.css");
            writer.WriteAttributeString("id", "cssRef");
            writer.WriteAttributeString("media-type", "text/css");
            writer.WriteEndElement();

            // toc file ref
            writer.WriteStartElement("item");
            writer.WriteAttributeString("href", "toc.ncx");
            writer.WriteAttributeString("id", "ncx");
            writer.WriteAttributeString("media-type", "application/x-dtbncx+xml");
            writer.WriteEndElement();

            writer.WriteEndElement(); // End Manifest

            // Spine
            writer.WriteStartElement("spine");
            writer.WriteAttributeString("toc", "ncx");

            for (int i = 0; i < fileCount; i++)
            {

                writer.WriteStartElement("itemref");
                writer.WriteAttributeString("idref", "item" + i.ToString());
                writer.WriteAttributeString("linear", "yes");
                writer.WriteEndElement();

            }



            writer.WriteEndElement(); // End Spine

            writer.WriteStartElement("guide"); // Start Guide

            // References
            writer.WriteStartElement("reference");
            writer.WriteAttributeString("type", "toc");
            writer.WriteAttributeString("title", "Contents");
            writer.WriteAttributeString("href", "contents.html");
            writer.WriteEndElement();

            writer.WriteStartElement("reference");
            writer.WriteAttributeString("type", "cover");
            writer.WriteAttributeString("title", "Cover");
            writer.WriteAttributeString("href", coverHref);
            writer.WriteEndElement();


            writer.WriteEndElement(); // End Guide

            writer.WriteEndElement(); // Close package element


            writer.Flush();
            writer.Close();
        }

        private static void CreateTocFile(string directory, EPUBSettings settings)
        {
            // Toc Html
            //WriteContentHTML(settings);
            XmlWriter writer = XmlWriter.Create(directory + "/OEBPS/" + "contents.html", _xmlSettings);

            // Html Begin
            writer.WriteStartElement("html", "http://www.w3.org/1999/xhtml");
            // Head
            writer.WriteStartElement("head");
            // Title
            writer.WriteElementString("title", settings.Title);

            writer.WriteEndElement(); // End Head
                                      // Body
            writer.WriteStartElement("body");
            // Content Header
            writer.WriteStartElement("h2");
            writer.WriteAttributeString("id", "contentStart");
            writer.WriteValue("Contents");
            writer.WriteEndElement();

            writer.WriteEndElement(); // End Body
            writer.WriteEndElement(); // End Html
            writer.Flush();
            writer.Close();

            // Toc.ncx
            //WriteTocxFile();
            XmlWriter writeToc = XmlWriter.Create(directory + "/OEBPS/" + "toc.ncx", _xmlSettings);
            writeToc.WriteDocType("ncx", "-//NISO//DTD ncx 2005-1//EN", "http://www.daisy.org/z3986/2005/ncx-2005-1.dtd", null);
            // ncx Start
            writeToc.WriteStartElement("ncx", "http://www.daisy.org/z3986/2005/ncx/");
            writeToc.WriteAttributeString("version", "2005-1");
            writeToc.WriteAttributeString("xml", "lang", null, "en");
            // head start
            writeToc.WriteStartElement("head");

            // Meta Content Attribute
            writeToc.WriteStartElement("meta");
            writeToc.WriteAttributeString("name", "dtb:depth");
            writeToc.WriteAttributeString("content", "1");
            writeToc.WriteEndElement();

            writeToc.WriteStartElement("meta");
            writeToc.WriteAttributeString("name", "dtb:generator");
            writeToc.WriteAttributeString("content", "Graphic Novel Generator by Karl Martinsson (Rags)");
            writeToc.WriteEndElement();

            writeToc.WriteEndElement(); // head End
            // docTitle start
            writeToc.WriteStartElement("docTitle");
            writeToc.WriteElementString("text", settings.Title);
            writeToc.WriteEndElement(); // End docTitle
            // navMap
            writeToc.WriteStartElement("navMap");
            // navPoint

            int chapterNR = 1;
            List<string> filesInDirectory = Directory.GetFiles(directory + "/OEBPS").ToList();
            //
            //  Nav Chapters
            //
            // If chapter nr (c00X) is not 1, set chapterNR to that nr
            string? chNumTry = filesInDirectory.Find(filename =>
            {
                return Regex.IsMatch( Path.GetFileName(filename), _chapterPattern1 ) || Regex.IsMatch(filename, _chapterPattern2 ); 
            });
            if (chNumTry != null)
            {
                bool is1Match = Regex.IsMatch(Path.GetFileName(chNumTry), _chapterPattern1);
                bool is2Match = Regex.IsMatch(Path.GetFileName(chNumTry), _chapterPattern2);

                string first = Regex.Match(chNumTry, _chapterPattern1).Value.Replace("c", "");
                string second = Regex.Match(chNumTry, _chapterPattern2).Value.Replace("-", "");

                chapterNR = Regex.IsMatch(Path.GetFileName(chNumTry), _chapterPattern1) ?
                    int.Parse(Regex.Match(chNumTry, _chapterPattern1).Value.Replace("c", "")) :
                    int.Parse(Regex.Match(chNumTry, _chapterPattern2).Value.Replace("-", ""));
            }

            writeToc.WriteStartElement("navPoint");
            writeToc.WriteAttributeString("id", "np-" + chapterNR.ToString());
            writeToc.WriteAttributeString("playOrder", chapterNR.ToString());
            // navLabel
            writeToc.WriteStartElement("navLabel");
            writeToc.WriteElementString("text", "Chapter " + chapterNR.ToString());
            writeToc.WriteEndElement(); // End Navlabel
                                        // content

            string firstFile = Directory.GetFiles(directory + "/OEBPS")[0];
            writeToc.WriteStartElement("content");
            writeToc.WriteAttributeString("src", Path.GetFileName(firstFile));
            writeToc.WriteEndElement(); // End content
            writeToc.WriteEndElement(); // End Navpoint

            filesInDirectory.ForEach(file =>
            {
                if (Regex.IsMatch(Path.GetFileName(file), _chapterPattern1) || Regex.IsMatch(Path.GetFileName(file), _chapterPattern2))
                {
                    int chapNrForFile = Regex.IsMatch(Path.GetFileName(file), _chapterPattern1) ?
                        int.Parse(Regex.Match(file, _chapterPattern1).Value.Replace("c", "")) :
                        int.Parse(Regex.Match(file, _chapterPattern2).Value.Replace("-", ""));
                    // If chapter nr has changed, add to content list, else continue
                    if (chapterNR != chapNrForFile)
                    {
                        chapterNR = chapNrForFile;
                        writeToc.WriteStartElement("navPoint");
                        writeToc.WriteAttributeString("id", "np-" + chapterNR.ToString());
                        writeToc.WriteAttributeString("playOrder", chapterNR.ToString());
                        // navLabel
                        writeToc.WriteStartElement("navLabel");
                        writeToc.WriteElementString("text", "Chapter " + chapterNR.ToString());
                        writeToc.WriteEndElement(); // End Navlabel
                                                    // content

                    
                        writeToc.WriteStartElement("content");
                        writeToc.WriteAttributeString("src", Path.GetFileName(file));
                        writeToc.WriteEndElement(); // End content
                        writeToc.WriteEndElement(); // End Navpoint

                    }

                }

            });


            writeToc.WriteEndElement(); // End navMap
            writeToc.WriteEndElement(); // End ncx
            writeToc.Flush();
            writeToc.Close();
        }

        private static void AddCSS(string directory)
        {
            string css = "@charset \"utf-8\";\r\nbody, body.tei.tei-text {\r\n    color: black;\r\n    background-color: white;\r\n    margin: 0em;\r\n    width: auto;\r\n    border: 0;\r\n    padding: 0\r\n    }\r\ndiv, p, pre, h1, h2, h3, h4, h5, h6 {\r\n    margin-left: 0;\r\n    margin-right: 0;\r\n    display: block\r\n    }\r\ndiv.pgebub-root-div {\r\n    margin: 0\r\n    }\r\nh2 {\r\n    page-break-before: always;\r\n    padding-top: 1em\r\n    }\r\ndiv.figcenter span.caption {\r\n    display: block\r\n    }\r\n.pgmonospaced {\r\n    font-family: monospace;\r\n    font-size: 0.9em\r\n    }\r\na.pgkilled {\r\n    text-decoration: none\r\n    }\r\nimg.x-ebookmaker-cover {\r\n    max-width: 100%\r\n    }";
            ReadOnlySpan<byte> cssData = Encoding.ASCII.GetBytes(css);

            var cssFile = File.Create(directory + "/OEBPS/" + "pgepub.css");
            cssFile.Write(cssData);
            cssFile.Close();
        }

        private static void CreateMimeType(string directory)
        {
            var mimetype = File.Create(directory + "/mimetype");

            ReadOnlySpan<byte> mimeString = Encoding.ASCII.GetBytes("application/epub+zip");

            mimetype.Write(mimeString);
            mimetype.Close();
        }
        //
        // Private SubMethods
        //
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        
        private static void FormatAndSaveImages(string directory, string contentSource)
        {
            // Take image set and convert to jpeg
            string[] contents = Directory.GetFiles(contentSource);
            List<string> imageRef = new();

            foreach (string imgFile in contents) using (Bitmap bmp = new Bitmap(imgFile))
                {
                    string extension = Path.GetExtension(imgFile);
                    string name = Path.GetFileNameWithoutExtension(imgFile);
                    if (extension != ".jpeg")
                    {
                        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);


                        System.Drawing.Imaging.Encoder quality =
                            System.Drawing.Imaging.Encoder.Quality;

                        EncoderParameters encoderParameters = new EncoderParameters(1);
                        EncoderParameter encoderParameter = new EncoderParameter(quality, _settings.Compression);

                        encoderParameters.Param[0] = encoderParameter;

                        name = name.Replace(" ", "");
                        string path = Path.Combine(directory, "OEBPS", name + ".jpeg");
                        bmp.Save(path, jpgEncoder, encoderParameters);

                    }
                    else
                    {
                        var img = Image.FromFile(imgFile);
                        name = name.Replace(" ", "");
                        img.Save(Path.Combine(directory, "OEBPS", name + ".jpeg"));
                        img.Dispose();
                    }

                }
            foreach (string img in Directory.GetFiles(directory + "/OEBPS"))
            {
                if (Path.GetExtension(img) == ".jpeg")
                {
                    imageRef.Add(img);
                }
            }

            _imageRef = imageRef;

        }
        
        private static void CreateHtmlFile(string directory, string filename, string id, string title)
        {
            XmlWriter writer = XmlWriter.Create(directory + "/OEBPS/" + id + ".html", _xmlSettings);
            writer.WriteStartElement("html", "http://www.w3.org/1999/xhtml");

            writer.WriteStartElement("head"); // Start Head

            writer.WriteElementString("title", title);

            // CSS Ref
            writer.WriteStartElement("link");
            writer.WriteAttributeString("href", "pgepub.css");
            writer.WriteAttributeString("rel", "stylesheet");
            writer.WriteEndElement();

            writer.WriteEndElement(); // End Head

            writer.WriteStartElement("body"); // Start Body

            writer.WriteStartElement("div"); // Start Div
            writer.WriteAttributeString("style", "text-align: center");

            // Image
            writer.WriteStartElement("img");
            writer.WriteAttributeString("src", filename);
            writer.WriteAttributeString("alt", id);
            writer.WriteAttributeString("class", "x-ebookmaker-cover");
            writer.WriteEndElement();

            writer.WriteEndElement(); // End Div
            writer.WriteEndElement(); // End Body
            writer.WriteEndElement(); // End Html

            writer.Flush();
            writer.Close();
        }
    }
}


