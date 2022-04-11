
use kauman;

drop table if exists CartProduct;
drop table if exists Product;
drop table if exists Cart;
drop table if exists Category;
drop table if exists Manufacturer;
drop table if exists Email;
drop table if exists User;
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

create table User(
	userId int not null primary key auto_increment,
	userName varchar(255) not null,
	userPassword varchar(255) not null,
	firstName varchar(255) not null,
	lastName varchar(255),
	userPhoneNumber varchar(20),
	addressId int not null,
	foreign key (addressId) references Address(addressId)
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
    -- productImages image,
    manufacturerId int not null,
    productDesc varchar(255) not null, 
    productLength double,
    productWidth double,
    productWeight double,
    productRating double,
    -- productSKU image, 
    productPrice double,
    categoryId int not null,
    cartId int not null,
	foreign key (manufacturerId) references Manufacturer(manufacturerId),
    foreign key (categoryId) references Category(categoryId), 
    foreign key (cartId) references Cart(cartId)
);

create table CartProduct(
	cartProductId int not null primary key auto_increment,
	cartId int not null,
	productId int not null,
	foreign key (cartId) references Cart(cartId),
	foreign key (productId) references Product(productId)
);
