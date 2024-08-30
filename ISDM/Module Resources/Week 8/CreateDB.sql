CREATE TABLE Students(
SID CHAR(10), 
Sname VARCHAR(50), 
Address VARCHAR(50), 
dob DATE, 
NIC CHAR(10), 
CID CHAR(6));

CREATE TABLE Offers (
CID CHAR(6) ,
Mcod CHAR(6), 
Accadamic_year CHAR(2),
Semester INTEGER);

CREATE TABLE Module (
Mcode CHAR(6), 
Mname VARCHAR(50), 
M_Description VARCHAR(200), 
NoOfCredits INTEGER);

CREATE TABLE Course (
CID CHAR(6),
Cname VARCHAR(50),
C_Description VARCHAR(200),
C_fee INTEGER);
