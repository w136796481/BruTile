###BruTile
BruTile is a C# open source library to access tile services like OpenStreetMap and Bing. BruTile has few dependencies, is platform independent and has a limited scope. It is intended for reuse by other more sophisticated libraries

###Projects that use BruTile

* [ArcBruTile] (https://arcbrutile.codeplex.com/) a plugin for ArcGIS
* [SharpMap] (https://sharpmap.codeplex.com/) a GIS library
* [Mapsui] (https://github.com/pauldendulk/Mapsui) a slippy map that runs in Silverlight
* [DotSpatial] (https://dotspatial.codeplex.com/) a GIS library that is used in [HyrdroDesktop] (https://hydrodesktop.codeplex.com/)
* [PDOK] (https://www.pdok.nl/nl/producten/pdok-software/pdok-extensie-voor-arcgis) extensie voor ArcGIS

###Demo
Go [here] (http://brutiledemo.appspot.com/) for an online Silverlight demo of BruTile used in Mapsui

###Portable Class Library (PCL)
BruTile is a PCL with Profile336 which targets:

* .Net Framework 4.0.3 and higher
* Windows 8
* Windows Phone Silverlight 8
* Silverlight 5 
* Windows Phone 8.1
* Xamarin.iOS
* Xamarin.Android

###For downward compatibility we also compile for:
* .Net Framework 4.0
* .Net Framework 3.5

###Supported tile service protocols:
* TMS
* WMS-C
* WMS (a regular WMS called through the WMS-C protocol)
* WMTS
* ArcGIS Tile Server

###Known tiles sources:
There are number of specific tile source which are 

* OpenStreetMap
* MapQuest Aerial
* Bing
* Stamen
* Esri
* Google


###Roadmap
Here are our future plans: 

* Update automatic TileSchema generation to bring WMTS, WMS, TMS and WMSC in line.
* Rename all classes to get them in line with WMTS types.
* Better samples
* Better documentation
* Release v1

###Warnings
Note, this library is work in progress. It is in BETA.

* At the moment there is no documentation.
* We will introduce breaking changed frequently. We change the API whenever we feel this is an improvement.
* We adopt new technologies relatively fast, dropping support for older frameworks.
* Although I do have a general plan of where to go with this library I do not have the resources to go towards that goal in a systematic way. I add functionality depending on what is needed in the projects I work on.

