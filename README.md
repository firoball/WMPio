# WMPio

Reader and writer API for Acknex3 WMP map files.
Acknex3 used to be a 3d game engine based on raycaster technology.

## Features

- Reads content of a WMP file (any version) into a set of A3 map object classes
- Writes a set of A3 map object class contents to an A3 WMP file (last version only)
- maintain compatibility to Acknex3 v3.9

## Limitations

Acknex3 heavily depends on WDL script definitions for map objects. WMPio does not handle parsing of WDL files.
A 100% accurate representation of any A3 map is only possible with obtaining additional details from object definitions found in WDL scripts.
WMP files only contain the level layout and some very basic parameters.
If in need of a WDL parser you may want to take a look at [https://github.com/firoball/WDL2CS](WDL2CS).

## Out of scope

WMPio is targeted at Acknex3 only.
There exist multiple versions of the Acknex game engine. From Acknex4 on, the technology has changed completely. WMPio won't work with versions other than v3.x.

## Trivia

This project started as a test in order to find out how well ChatGPT can generate parsers for custom mostly unknown file formats.
It worked pretty well - main work left was coming up with some better abstraction and some additional measures against crashes while parsing garbage content.

## Legal stuff

Please respect [license.txt](license.txt) (Attribution-NonCommercial 4.0 International)

-firoball

[https://firoball.de](https://firoball.de)

