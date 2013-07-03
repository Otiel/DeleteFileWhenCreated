DeleteFileWhenCreated
=====================

Description
-----------

_DeleteFileWhenCreated_ is a command line application written in C# for Windows that can be used to delete a file as soon as it is created.

_DeleteFileWhenCreated_ registers a file watcher to detect when the file is created, and deletes it instantly. The application runs in the background and can only be stopped through the Task Manager.

Usage
-----

1. If you simply don't care about the sources, download the latest version from the [releases](https://github.com/Otiel/DeleteFileWhenCreated/releases) page as a zip file.
2. Open a command line (Win+R -> cmd).
2. Run `"C:\[path to exe]\Latest version\DeleteFileWhenCreated.exe" "C:\[path to file]\myFileToDelete"`.

Bugs/Ideas
----------

If you have a bug to report, or simply an idea for an improvement or a new feature, please add them in the [issue tracker](https://github.com/Otiel/DeleteFileWhenCreated/issues).

License
-------

_DeleteFileWhenCreated_ is licensed under the [WTFPL](http://www.wtfpl.net/) ![WTFPL icon](http://i.imgur.com/AsWaQQl.png).
