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

    HtmlUniqueWords.exe https://simbirsoft.com SimbirsoftLocal.html

It saves the *.html* file from the specified _URL-adress_ to the _.\html\localfile_
and counts the number of unique words in the the saved file.
Result is saved in the  local SQLite3 database in *.\SqLite* directory and output to the console.

## Comment

This program was created as test for admission to **Java and C #. Backend-workshop online from the IT company [SimbirSoft](https://www.simbirsoft.com/)**.

## License

_HtmlUniqueWords_ using these libraries:

- [HtmlAgilityPack;](https://github.com/zzzprojects/html-agility-pack)
- [NLog](https://github.com/NLog/NLog) created by Jaroslaw Kowalski <jaak@jkowalski.net>, Kim Christensen, Julian Verdurmen.


---


## Описание

_HtmlUniqueWords_ подсчитывает количество уникальных слов на веб-странице.

## Использование программы

Программа принимает два аргумента:

_URL-adress_ - URL адрес веб-страницы с указанием протокола _http_ или _https_;<br/>
_localfile_ - _.html_ файл.

Запуск, используя командную строку:

    HtmlUniqueWords.exe URL-adress localfile

Пример:

     HtmlUniqueWords.exe https://simbirsoft.com SimbirsoftLocal.html

Программа сохраняет *.html* файл с указанного _URL-adress_ в _.\html\localfile_ и вычисляет количество уникальных слов в сохраненном файле. Результат сохраняется в локальной **SQLite3** базе данных в директории *.\SQLite* и выводится в консоль.

## Примечание

Программа разрабатывалась в качестве тестового задания для поступления на **Java и C#. Backend-практикум онлайн от IT-компании [SimbirSoft](https://www.simbirsoft.com/)**.

## Лицензии
_HtmlUniqueWords_ использует следующие библиотеки:

- [HtmlAgilityPack;](https://github.com/zzzprojects/html-agility-pack)
- [NLog](https://github.com/NLog/NLog) разработанную Jaroslaw Kowalski <jaak@jkowalski.net>, Kim Christensen, Julian Verdurmen.
