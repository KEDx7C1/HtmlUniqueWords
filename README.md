# HtmlUniqueWords

## Description 

_HtmlUniqueWords_ counts unique words on a web page.

## Using program

Program takes two arguments:

_URL-adress_ is URL adress of the web page with specifying protocol _http_ or _https_;<br/>
_localfile_ is file with _.html_ extention.

Use command prompt:

    HtmlUniqueWords.exe URL-adress localfile



Example:

    HtmlUniqueWords.exe https://google.com GoogleLocal.html

It saves the *.html* file from the specified _URL-adress_ to the _localfile_
and counts the number of unique words in the *body* tag of the saved file.
Result is saved in the  local SQLite3 database and output to the console.

## Appendix

This program was created as test for admission to **Java and C #. Backend-workshop online from the IT company [SimbirSoft](https://www.simbirsoft.com/)**.

## License

_HtmlUniqueWords_ using whose libraries:

- [HtmlAgilityPack;](https://github.com/zzzprojects/html-agility-pack)
- [NLog](https://github.com/NLog/NLog) created by Jaroslaw Kowalski <jaak@jkowalski.net>, Kim Christensen, Julian Verdurmen.
