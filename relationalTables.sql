CREATE TABLE ReviewTable( 
    reviewID VARCHAR(30),
    userID VARCHAR(30) NOT NULL,
    busID VARCHAR(30) NOT NULL,
    text VARCHAR(2000),
    date_ DATE,
    cool INTEGER,
    useful INTEGER,
    funny INTEGER,
    stars FLOAT,
    PRIMARY KEY(reviewID, userID, busID),
    FOREIGN KEY (busID) REFERENCES Business(busID),
    FOREIGN KEY (userID) REFERENCES userTable(userID)
);


CREATE TABLE userTable(
    userID VARCHAR(30) PRIMARY KEY,
    Uname CHAR(50),
    yelpingSince DATE,
    funny INTEGER,
    cool INTEGER,
    useful INTEGER,
    fans INTEGER,
    reviewCount INTEGER,
    avgStar FLOAT
);

CREATE TABLE Business (
    BusID VARCHAR(30) PRIMARY KEY,
    bname VARCHAR(120),
    addr VARCHAR(100),
	city VARCHAR(50),
	state_ VARCHAR(10),
    postalCode INTEGER,
    latitude FLOAT,
    longitude FLOAT,
    bStars FLOAT,
    reviewCount INTEGER,
    isOpen BOOLEAN,
	reviewRatings FLOAT,
	numCheckins INTEGER
);


CREATE TABLE FriendsTable (
    userID VARCHAR(30),
    friendID VARCHAR(30),
    PRIMARY KEY(userID, friendID),
    FOREIGN KEY (userID) REFERENCES userTable(userID)
);


CREATE TABLE Categories (
    cname VARCHAR(45) PRIMARY KEY
);



CREATE TABLE BusinessCategories (
    busID VARCHAR(30),
    cname VARCHAR(100),
    PRIMARY KEY(busID, cname),
    FOREIGN KEY (busID) REFERENCES Business(busID),
    FOREIGN KEY (cname) REFERENCES Categories(cname)
);


CREATE TABLE CheckIn (
    busID VARCHAR(30),
    DayOfWeek VARCHAR(10),
    morning CHAR(30),
    afternoon CHAR(30),
    evening CHAR(30),
    night CHAR(30),
    PRIMARY KEY (busID, DayOfWeek),
    FOREIGN KEY (busID) REFERENCES Business(busID)
);


CREATE TABLE Hours (
    busID VARCHAR(30),
    dayOfWeek VARCHAR(20),
    opens CHAR(10),
    closed CHAR(10),
    PRIMARY KEY (busID,dayOfWeek),
    FOREIGN KEY (busID) REFERENCES Business(busID)
);

CREATE TABLE Attributes (
    aname VARCHAR(200) PRIMARY KEY
);

CREATE TABLE BusinessAttributes(
    busID VARCHAR(30),
    aname VARCHAR(100),
    value_ VARCHAR(100),
    PRIMARY KEY(busID, aname),
    FOREIGN KEY (busID) REFERENCES Business,
    FOREIGN KEY (aname) REFERENCES Attributes
);



