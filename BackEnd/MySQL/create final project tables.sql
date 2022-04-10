drop table if exists CartProduct;
drop table if exists Cart;
drop table if exists User;
drop table if exists Email;
drop table if exists Address;
drop table if exists Country;
drop table if exists State;

create table State(
stateId int primary key not null auto_increment,
name varchar(255) not null
);

create table Country(
countryId int primary key not null auto_increment,
name varchar(255) not null
);

create table Address(
addressId int primary key not null auto_increment,
zip varchar(10) not null,
streetAddress varchar(255) not null,
city varchar(255) not null,
stateId int,
countryId int not null,
foreign key (stateId) references State(stateId),
foreign key (countryId) references Country(countryId)
); 

create table User(
userId int primary key not null auto_increment,
userName varchar(255) not null,
userPassword varchar(255) not null,
firstName varchar(255) not null,
lastName varchar(255),
userPhoneNumber varchar(20),
addressId int not null,
foreign key (addressId) references Address(addressId)
);

create table Email(
emailId int primary key not null auto_increment,
address varchar(255) not null,
userId int not null,
foreign key (userId) references Person(userId)
);

create table Cart(
cartId int primary key not null auto_increment,
userId int not null,
foreign key (userId) references User(userId)
); 

create table CartProduct(
cartProductId int primary key not null auto_increment,
cartId int not null,
productId int not null,
foreign key (cartId) references Cart(cartId),
foreign key (productId) references Product(productId)
);