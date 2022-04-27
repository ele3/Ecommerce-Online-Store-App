
-- use 'your local db name'; 

drop table if exists CartProduct;
drop table if exists Product;
drop table if exists Cart;
drop table if exists Category;
drop table if exists Manufacturer;
drop table if exists Email;
drop table if exists User;
drop table if exists Card;
drop table if exists Address;
drop table if exists Country;
drop table if exists State;

create table State(
	stateId int not null primary key auto_increment,
	state varchar(255) not null
);

create table Country(
	countryId int not null primary key auto_increment,
	country varchar(255) not null
);

create table Address(
	addressId int not null primary key auto_increment,
	zip varchar(10) not null,
	streetAddress varchar(255) not null,
	city varchar(255) not null,
	stateId int,
	countryId int not null,
	foreign key (stateId) references State(stateId),
	foreign key (countryId) references Country(countryId)
); 

-- a user may have multiple cards
create table Card(
	cardId int not null primary key auto_increment,
    cardNumber varchar(30) not null,
    cardExpiration varchar(30) not null,
    cardCCV varchar(4) not null
);

create table User(
	userId int not null primary key auto_increment,
	userName varchar(255) not null,
	userPassword varchar(255) not null,
	firstName varchar(255) not null,
	lastName varchar(255),
	userPhoneNumber varchar(20),
    adminId varchar(10),-- this takes care of the "admin" table
	addressId int not null,
    cardId int,
	foreign key (addressId) references Address(addressId),
    foreign key (cardId) references Card(cardId)
);

create table Email(
	emailId int not null primary key auto_increment,
	address varchar(255) not null,
	userId int not null,
	foreign key (userId) references User(userId)
);

# This table respresents a Manufacturer and has a one to many relationship with the Product table
create table Manufacturer (
	manufacturerId int not null primary key auto_increment,
    manufacturerName varchar(255) not null
);

# This table respresents a Category and has a one to many relationship with the Product table
create table Category (
	categoryId int not null primary key auto_increment,
    categoryName varchar(255) not null
);

create table Cart(
	cartId int not null primary key auto_increment,
	userId int not null,
	foreign key (userId) references User(userId)
); 

# This table respresents a Product
create table Product (
	productId int not null primary key auto_increment,
	productName varchar(255) not null, 
    productImage varchar(255) not null, 
    manufacturerId int not null,
    productDesc varchar(255) not null, 
    productLength double,
    productWidth double,
    productWeight double,
    productRating double,
    -- productSKU image, 
    productPrice double,
    categoryId int not null,
    foreign key (manufacturerId) references Manufacturer(manufacturerId),
    foreign key (categoryId) references Category(categoryId)
);
-- a checkout is created from CartProduct whenever a user moves to the checkout page
-- and is deleted apon leaving the page.
create table CartProduct(
	cartProductId int not null primary key auto_increment,
	cartId int not null,
	productId int not null,
	quantity int,
	foreign key (cartId) references Cart(cartId),
	foreign key (productId) references Product(productId),
	constraint uniquePair unique index(cartId,productId)
);

insert into State(state)
values('Nebraska'),
('Wyoming'),
('Edinburgh'),
('England'),
('Wales'),
('New York'),
('California'),
('Alabama'),
('Kansas'),
('Washington'),
('Colorado')
;

insert into Country(country)
values('UK'),
('USA'),
('France'),
('Germany'),
('Netherlands'),
('Italy'), 
('Ireland'),
('Scotland')
;

insert into Address(streetAddress, city, stateId, zip, countryId)
values('3288 Interdum. Ave','Portofino',8,'8222 GK',2),
('7414 Mattis St.','Hudson Bay',8,11910,2),
('1773 Donec Rd.','Saint-Lô',7,25052,2),
('7258 Dui. Ave','Jennersdorf',7,341791,2),
('319-5288 Ullamcorper. Av.','Bossire',7,638973,2),
('412-2699 Urna Av.','Erchie',6,'CD3 3FW',2),
('Ap #822-5190 Tortor. St.','Pozzuolo del Friuli',2,951521,2),
('362-7259 Diam Rd.','Lagundo/Algund',9,329171,2),
('7217 Phasellus St.','Saratov',9,7579,2),
('6283 Rhoncus. St.','Shenkursk',8,866779,2),
('7055 Nibh. Street','Quinta de Tilcoco',11,09315-541,2),
('693-8278 Ultrices Street','Chía',9,450622,2),
('228-9715 Non Road','Côte Saint-Luc',9,994673,2),
('573-6764 Scelerisque Street','Nurda??',8,258868,2),
('2944 Sem Avenue','Grand Falls',11,2192,2),
('Ap #659-6787 Nec Road','Woodlands County',11,413074,2),
('6434 Gravida. St.','Bargagli',10,43010,2),
('7479 Nunc Road','Fortune',11,15398,2)
;

insert into User(userName, userPassword, firstName, lastName, userPhoneNumber, addressId) 
values('Tim', 1234, 'Tim', 'Baggins', 123-450-6544, 1),
('bilbo', 1235, 'bilbo', 'Baggins', 123-456-7890, 2),
('Frodo', 1236, 'Frodo', 'Baggins', 123-456-6544, 3);

insert into Email(address, userId)
values('TimmyB@at.com',1),
('BillyBob@theShire.com',2),
('Frodo.Baggins@theShire.com',3);

insert into Manufacturer (manufacturerName)
values ('Crocs, Inc.'),
('Adidas'),
('Nike'),
('Amazon');

insert into Category (categoryName)
values ('Crocs'),
('Yeezys'),
('Jordans'),
('Accessories');

insert into Product (productName, manufacturerId, productImage, productDesc, productLength, productWidth, productWeight, productRating, productPrice, categoryId)
values ('Aringa Mens Garden Clog',1,'~/assets/catalog-pics/crocs/crocs1.jpg','Khaki',11.34,9.61,2.78,4.1,27,1),
('Classic Women Leopard Print Clog',1,'~/assets/catalog-pics/crocs/crocs2.jpg','Leopard Print',11.34,9.61,2.78,4.5,58,1),
('Crocband II Clog',1,'~/assets/catalog-pics/crocs/crocs3.jpg','Ice Blue',11.34,9.61,2.78,3.9,39,1),
('Offroad Sport Clog',1,'~/assets/catalog-pics/crocs/crocs4.jpg','Black',11.34,9.61,2.78,4.2,25,1),
('Oreo Boost 350 V2',2,'~/assets/catalog-pics/yeezys/buy-1.jpg','Black, White, and Red',13.5,9.6,2.65,4.7,387,2),
('Black Boost 350 V2',2,'~/assets/catalog-pics/yeezys/blackyz.jpg','Black and Red',13.5,9.6,2.65,4.2,288,2),
('Blue Boost 350 V2',2,'~/assets/catalog-pics/yeezys/lightblueyz1.jpg','Grey, Light Blue, and Red',13.5,9.6,2.65,4.6,210,2),
('Orange Boost 350 V2',2,'~/assets/catalog-pics/yeezys/orangeyz.jpg','Grey and Orange',13.5,9.6,2.65,4.1,188,2),
('Brown Boost 350 V2',2,'~/assets/catalog-pics/yeezys/brownyz.jpg','Earth Brown',13.5,9.6,2.65,4.9,198,2),
('Jordan 6 Retro UNC University Blue/White-Black',3,'~/assets/catalog-pics/jordans/jordans1.jpg','University Blue, White, and Black',13.25,8.5,2.5,4.7,697,3),
('Air Jordan 1 Mid Grade School',3,'~/assets/catalog-pics/jordans/jordans2.jpg','White and Black',13.25,8.5,2.5,3.8,898,3),
('Air Jordan 4 Retro - Yellow',3,'~/assets/catalog-pics/jordans/jordans3.jpg','Yellow, White, and Black',13.25,8.5,2.5,4.3,399,3),
('Air Jordan 4 Retro- White',3,'~/assets/catalog-pics/jordans/jordan4.jpg','White, Black, and Red',13.25,8.5,2.5,4.1,499,3),
('Grey Shoes Bag',4,'~/assets/catalog-pics/accessories/acc1.jpg','Black',19.6,12.4,7.5,4.5,38,4),
('Foot Fitter',4,'~/assets/catalog-pics/accessories/acc2.jpg','Tan',12.5,6,2.4,4.2,42,4),
('Shoe Laces',4,'~/assets/catalog-pics/accessories/acc3.jpg','White, Black, Grey, and Brown',27,0.5,0.1,4.6,9,4),
('Lock Laces',4,'~/assets/catalog-pics/accessories/acc4.jpg','Silver and Black',28,0.2,0.3,4.9,15,4),
('Epoxy Spiked Shoes',4,'~/assets/catalog-pics/accessories/acc5.jpg','Green and Silver',14.8,10,3.2,0.1,88,4);
