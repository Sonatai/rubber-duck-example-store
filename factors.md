# 12 Factors Description

## Umsetzung der Goals

Ich habe mich für einen exemplarischen Webshop entschieden, da dieser sich meiner Meinung nach gut für eine Microservice Architecture eignet. Mein "Backend" besteht aus 3 Services:

- User Service: Hier werden User Login Daten verwaltet und angelegt
- Product Catalogue Service: Hier liegen alle Produkte, die wir anbieten. Sie können per REST API lesend abgefragt werden.
- Cart Service: Hier werden die Warenkörbe pro Nutzer verwaltet.

Zusätzlich habe ich mich für lediglich ein Frontend entschieden. Das Frontend greift auf die Services zu und holt sich die Informationen, die es braucht. Ggf. legt es auch Daten an oder aktualisiert sie. Eine Lösch-Operation ist nicht im Frontend implementiert.

Die Services können unabhängig von einander gestartet und aufgerufen werden. Das Frontend braucht allerdings alle 3 Services, um zu funktionieren.

## No 1 Codebase

Ich hab Github als Repo genutzt, das auf git basiert. Es gibt einen main-branch, der stable sein sollte. Normalerweise hätte ich den main-branch für direkte merges geblockt, eine Build & Deploy Pipeline aufgezogen sowie PR mendatory gemacht. Außerdem hätte ich dann noch Tests geschrieben, sowie Quality Gates eingerichtet. Für dieses kleine Projekt habe ich drauf verzichtet.

Prinzipiell kann aber die Codebase via Docker mehrfach gebaut und im Anschluss mittels einer Pipeline auf mehreren Stages deployed werden.

Wenn benötigt kann aber auch auf vorherige Versionen zurückgeriffen werden und diese gebaut und deployed werden.

## No 2 Dependencies

Verschiedene Dependencies werden in der Programm.cs des jeweiligen Services registriert und im Anschluss im Code verwendet. Da das Projekt klein ist, habe ich auf Interfaces für eigene Klassen verzichtet. Ich fand, sie gaben den Projekt nicht viel mehr Mehrwert. Außerdem verwende ich auch nuget packages.

Im Frontend benutze ich yarn als bundler und sammel die Dependencies in der package.json.

## No 3 Config

Im Frontend habe ich keine Config benutzt - aber normalerweise müsste die Base Url per Service eingetragen werden. Ich hatte es vergessen und hab jetzt keine Zeit mehr 🤷‍♀️

In den einzelnen Services werden wichtige Configs (wie z.B. Database) in den appsettings.json eingetragen. .Net7 erlaubt es auch verschiednee appsettings per Enviroment zu haben. In meinem Fall sind beide gleich, da ich keine wirkliche Produktion habe und es für Development bzw. Local entwickelt hab.

## No 4 Backing services

Wenn ich jetzt eine MongoDb Instanz in der Cloud haben möchte, kann ich für die Production Stage einen anderen ConnectionString hinterlegen. Ich kann auch Db Name und Collection Name für Prod ändern - falls gewünscht.

## No 5 Build, release, run

Eine Build Pipeline inklusive Release und Deployment habe ich jetzt nicht aufgezogen. Prinzipiell hätte ich z.B. in Azure Devops ein Terra Template für Build & Test sowie Deployment erstellt und diese pro Stage angepasst. Die Variabeln könne via Enviroment Variabeln (in Azure selber), Key Vault und/oder Appsetting ausgelesen werden.

Den Build würde ich beim PR und nach dem Merge rennen lassen. Deployment kann entweder automatisch oder manuell getriggert werden. Beides hat Vor- und Nachteile wobei ich auf Production niemals automatisch deployn würde.

In Azure können auch Tags vergeben werden für einen Commit => somit können Versionen vergeben werden.

## No 6 Processes

Ich glaub, das hab ich nicht zu 100% eingehalten?
Prinzipiell ist jeder Service für sich allein nutzbar. User Service und Cart Service nutzen jeweils eine eigene MongoDb Instanz, um Daten zu persistieren.

Allerdings liegen in meinem Product Catalogue Service Produkte in Form von Jsons und Jpgs. Grund dafür ist, dass es ein rein lesender Service aktuell ist und ich eine DB nicht für sinnvoll hielt. Wenn ich aber ganz korrekt hätte sein wollen, dann hätte ich wohl die Daten anders abgelegen müssen. Beispielsweise ein Blob Storage oder eine DB. Evtl ein externes File System.

Ich hab mich dagegen entschieden, da ich es für ausreichend hielt sie im Service selber abzulegen für dieses Studien-Projekt.

## No 10 Dev/prod parity

Da ich nur "eine" Stage habe, sind sie natürlich alle gleich.
Ich denke aber, dass dieser Punkt diskutierbar ist.

In der Regel würde ich den Technologie-Stack gleich halten. Eine Ausnahme können aber z.B. Datenbanken sein. Beispielsweise könnte ich für das lokale Entwickeln eine in Memory Datenbank verwenden, während meine Stages eine MSSql Datenbank Instanz in der Cloud verwenden. Ich würde halt nicht von einer MongoDB local zu einer PostgreSQL Datenbank auf den Stages wechseln. Aber ja prinzipiell würde ich den Technologie-Stack immer so gleich wie möglich halten. Das entspricht auch meiner bisherigen Erfahrung in der Berufswelt.

Zum Thema Deployment: In meinem Unternehmen ist es in der Regel nicht erlaubt einfach so auf die PROD zu deployen. Wir deployen in regelmäßigen Abständen (quartalsweise) gebündelt mehrere Commits zu einem Release. Dies tut dann eine bestimmte Person, die dann auch dafür sorgt das Regression Tests etc laufen.

Davor wird der Code auf Dev & Test nochmal getestet und dort bin ich dann für meinen Code zuständig.

Ich denke der Deployment-Part ist eher für kleinere Unternehmen, die ggf häufiger PROD Deploymnents machen. Ich würde es aber immer eher bevorzugen zu bestimmten Zeitpunkten auf PROD zu deployen als "nach Lust und Laune". Auch weil es dann mit etwaigen Release-Patchnotes einfacher wird 😅 Ausnahmen sind natürlich Hotfixes.

Der Time Gap schneidet in die selbe Kerbe. Ich denke aber nicht, dass es wirklich ein Problem ist. Die ABN ist in der Regel die PROD + "neue stable features". D.h. spätestens da sehe ich, ob mein Code Probleme verursacht. In der Regel sehe ich es aber früher auf der Test Stage oder sogar Dev Stage. Ich denke der Punkt stammt vllt aus einer Zeit, wo es nicht üblich war mehrere Stages zu haben, auf denen ausgiebig getestet wird?

## No 11 Logs

.Net bietet eine standardisierte Log Lib mit einer Abstraktion an. Diese habe ich in meinen Commands & Queries verwendet.
