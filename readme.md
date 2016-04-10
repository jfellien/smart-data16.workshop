##Smart Data Cqrs + OrientDB Workshop

Es wird eine CQRS Applikation gebaut, die als Datenbank eine OrientDB verwendet.

###Voraussetzungen
 
 * Installierte OrientDB
 * VisualStudio 2013 oder höher
 * git Client
 * node.js 4.x Installation
 
###Aufgabe
Entwicklung einer Applikation zur Terminabfrage für Möbellieferungen mit CQRS. Hierfür wird Fluent-Cqrs verwendet.

####Einrichten der Umgebung
 
 * Herunterladen des Projektes mit `git clone git@github.com:jfellien/smart-data16.workshop.git`
 * Installieren der Pakete mit `.paket/paket.bootstrapper.exe` dann `.paket/paket.exe install` bzw `.paket/paket.exe restore`


####OrientDB Server einrichten

 * bin/server.bat in der Console ausführen
    * wenn Java fehlt, dann nachinstallieren (jre oder jdk am besten)
    * falls Server Fehler kommt, `client` Verzeichnis im Java Verzeichnis kopieren und in `server` umbenennen
 * root Passwort automatisch generieren lassen
 * im Browser http://localhost:2480 aufrufen

####Datenbanken einrichten

Für die Applikation werden zwei Datenbanken benötigt, ein EventStore und die Datenhaltung für die Views

#####EventStore

 * Der EventStore wird als Document DB angelegt, mit zwei Klassen
 * In der Web UI `NewDB` anklicken und mit dem root User und seinem Passwort (zu finden in der config/orientdb-server-config.xml) die DB anlegen
 * Als {document} für die Events eine neue Klasse `Event` ohne Properties anlegen
 * Für die Metadaten eines Events eine neue Klasse `EventBag` mit den folgenden Properties anlegen
    * Id STRING
    * Timestamp DateTime
    * EventType STRING
    * Payload EMBEDDED Event

#####ReadModel

...

