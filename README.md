# _bandtracker_

#### _Interactive bandtracker application that allows entry of new bands, and venues. Each band can be clicked to allow the user to view each venue played. Each venue can be clicked to allow the user to view each band that played there.  Bands, and venues can be added. _

#### By _**Rick Thornbrugh.**_

## Description

_User starts at the index page.  There are two options; view Band, and view Venue. If Venue is selected, page redirects to Venue page. A list of venues will appear on the screen. The venues are clickable. The venue may be edited, and/or deleted. New venues may be added. If a venue is selected, page will redirect to the selected venue.  The venue page will list all bands that have played there. If the user selects band, they will be redirected to a band page where a list of bands will appear. The Bands are clickable. New Bands may be added. If a Band is selected, page will redirect to the selected Band.  The selected band page will list all venues that the band has played._

## Setup/Installation Requirements

_File can be cloned from Github @ [https://github.com/Rick1970/bandtracker].
Created in C# with atom text editor.  Used Nancy framework, and razor view engine.  To run the file after download; first run dnu restore from the command line in order to link to the project.lock.json file. Set up the server by:
In SQLCMD -S "(localdb)\mssqllocaldb"

CREATE DATABASE band_tracker;
GO
USE band_tracker;
GO
CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255));
CREATE TABLE bands (id INT IDENTITY(1,1), description VARCHAR(255));
CREATE TABLE venues_bands (id INT IDENTITY(1,1), venue_id INT, band_id INT);
GO
Open SMSS. Backup the band_tracker file.  Then restore the band_tracker file.  Rename as band_tracker_test during restore.  A mirror test copy will be created. _

## Known Bugs
_None known._

## Support and contact details

_Contact the author at [rthornbrug@gmail.com]._

## Technologies Used

_Atom text editor, in C#, with Nancy framework and razor view engine, xunit testing, Sql server, running on Kestrel server._

### License

*MIT License

*Copyright (c) [201
