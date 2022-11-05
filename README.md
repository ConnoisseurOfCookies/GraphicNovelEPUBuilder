# Graphic Novel EPUB Builder

<h2>Description</h2>

A simple tool to create E-reader compatible EPUB files out of image collections

<h2>Index</h2>
<ul>
<li><a href="#instructions">Instructions</a></li>
<li><a href="#issues">Issues</a></li>
</ul>

<h2 id="instructions">Instructions</h2>

***

<h2>File naming</h2>
Filenaming convention is Title-Chapter-Page.

* Chapter: -00x or p000
* Page: p000, p001, etc.
    * p000 is reserved for the cover page

<code>my_graphic_novel-c001-p000.jpeg</code>

They should be ordered chronologically. You can use the in-app bulk renaming tool if the files are ordered.


<h2>Folder Naming</h2>

If you're not compiling from multiple folders at once then it doesn't matter.

However, if you are the title will be the folder name. The renaming tool uses the <code>Name-Volume</code> convention, like so:

<code>MyNovel-v001</code>

<h2>Bulk Compiling</h2>

If you wan't to create multiple graphic novels tick the "Multiple Folders In Directory" checkbox. There should only be folders you intend to turn into EPUB files in the directory.

Make sure there are only image files in the folders and that they follow the naming convention, since the parsing relies heavily on namechecks. Also make sure they're ordered chronologically, page 1 first etc.


<h2>Bulk Renaming</h2>

If files and folders are ordered chronologically already you can use the bulk renaming tool. Simply select the target folder, choose a title and go. If you're renaming files from multiple folders make sure the parent directory is selected.

<h2>Compression</h2>

You can adjust the amount of compression by adjusting the slider, the lower the number the lower the quality. At 20, the default setting, a 220+ page novel at 300+ MB compresses down to about 45-50MB, and the images still look quite nice. Incidentally the limit for Kindle E-Mail transfer is around 50MB.

The lowest quality, 0, looks garbage and I do not reccommend. For a shorter comic, or lower quality files, you can get away with no compression.

<h2 id="issues">Issues</h2>

***

* I've been lazy so limited input validation and no error handling at the UI level

* Since this app resulted from a quick flight of fancy I haven't written unit or integration tests either, so edge cases are likely to occur


* Various metadata parsing not implemented in code:
    * Description
    * Tags
    * Author
    * Language
    
    <br>
* This is still a rather crude application but useable if input files are set up correctly