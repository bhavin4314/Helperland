CREATE DATABASE Helperland




CREATE TABLE Customers(c_id	int PRIMARY KEY,
first_name varchar(20),
last_name varchar(20),
email varchar(30),
mobile_no varchar(10),
password varchar(10),
address_id int FOREIGN KEY REFERENCES Customer_Address(address_id)
);







CREATE TABLE Customer_Address(
address_id	int PRIMARY KEY,
house_no	varchar(10),
street_name	varchar(50),
city	varchar(20),
postal_code	varchar(10)

);


CREATE TABLE Favourite_helper(
c_id	int FOREIGN KEY REFERENCES Customers(c_id),
h_id	int
);



CREATE TABLE Helpers(
h_id	int PRIMARY KEY,
first_name	varchar(20),
last_name	varchar(20),
email	varchar(30) UNIQUE,
mobile_no	varchar(10),
password	varchar(10),
postal_code	varchar(10),
average_rating	float

);


CREATE TABLE Helper_feedback(
c_id	int FOREIGN KEY REFERENCES Customers(c_id),
h_id	int FOREIGN KEY REFERENCES Helpers(h_id),
service_id	int,
rating	float,
feedback varchar(100)

);

CREATE TABLE Service(
c_id	int FOREIGN KEY REFERENCES Customers(c_id),
service_id	int PRIMARY KEY,
service_date	date,
service_time	time,
total_hour	int,
extra_service	varchar(100),
comments	varchar(200),
pets BIT

);

CREATE TABLE Reschedule_Order(
service_id	int FOREIGN KEY REFERENCES Service		
(service_id
),
new_date	date,
new_time	time,

);
CREATE TABLE Cancel_Order		
(
service_id	int FOREIGN KEY REFERENCES Service(service_id),
description	varchar(200)


);

CREATE TABLE Invoice(
c_id	int,
service_id	int FOREIGN KEY REFERENCES Service(service_id),
invoice_id	int PRIMARY KEY

);
CREATE TABLE Payment_details		
(
invoice_id	int FOREIGN KEY REFERENCES Invoice		
(invoice_id),
amount	int,
card_no	varchar(20),
Promo_code	varchar(20)


);
CREATE TABLE Refund_details			
(
invoice_id	int FOREIGN KEY REFERENCES Invoice,
refund_amount	int,
description	varchar(200)
);
CREATE TABLE visitors(
first_name	varchar(20),
last_name	varchar(20),
email	varchar(30),
Message	varchar(200),
);
ALTER TABLE Customers
ADD UNIQUE (email);


select * from Helpers		
