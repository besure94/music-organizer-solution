## Music Organizer

#### A web application that allows users to create a list of musical artists, and add albums by those artists to a list.

#### By Brian Scherner

## Technologies Used

* C#
* .NET
* ASP.NET MVC
* MySQL

## Description

This application presents users with a Home page where they can add the names of their favorite musical artists to a list. Users can then add their favorite albums by those artists to a list, which is stored inside each artist listing. Users can also add album artwork for each album by entering the album artwork URL. Users can view a list of all the artists they have added to the list, and they can clear the list and start over if they wish to do so.

## Setup Instructions

### Install Tools

Install the tools that are introduced in [this series of lessons on LearnHowToProgram.com](https://old.learnhowtoprogram.com/fidgetech-3-c-and-net/3-0-lessons-1-5-getting-started-with-c/3-0-0-01-welcome-to-c).

### Set up Project Databases

Follow the instructions in the LearnHowToProgram.com lesson ["Introduction to MySQL Workbench: Creating a Database"](https://old.learnhowtoprogram.com/fidgetech-3-c-and-net/3-3-database-basics/3-3-0-04-introduction-to-mysql-workbench-creating-a-database) to create a `music_organizer_with_mysqlconnector` database with a `records` table.

Next, follow the instructions in the LearnHowToProgram.com lesson ["Creating a Test Database: Exporting and Importing Databases with MySQL Workbench"](https://old.learnhowtoprogram.com/fidgetech-3-c-and-net/3-3-database-basics/3-3-0-08-creating-a-test-database-exporting-and-importing-databases-with-mysql-workbench) to create a `music_organizer_with_mysqlconnector_test` database with a `records` table.

### Set up and Run Project

1. Select the green button that says `Code`, and clone this repository.
2. Open your terminal and navigate to this project's production directory called `MusicOrganizer`.
3. In the production directory `MusicOrganizer`, create a new file called `appsettings.json`.
4. In `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL. For the LearnHowToProgram.com lessons, always assume the `uid` is `root` and the `pwd` is `epicodus`. Example below:

{

    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=music_organizer_with_mysqlconnector;uid=root;pwd=epicodus;",
      "TestConnection": "Server=localhost;Port=3306;database=music_organizer_with_mysqlconnector_test;uid=root;pwd=epicodus;"
    }

}

5. To run tests for the `Artist` and `Record` classes, navigate to this project's directory called `MusicOrganizer.Tests` and run the command `dotnet test` to test the classes.
6. In the production directory `MusicOrganizer`, run the command `dotnet watch run` to launch the project in development mode with a watcher.


## Known Bugs

Application is functioning fully as intended. I would like to add a feature for the user to search by an artists name at a later point, though.

## License

MIT

Copyright(c) 2023 Brian Scherner

