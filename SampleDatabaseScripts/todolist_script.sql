CREATE DATABASE todolist;
use todolist;

create table task (
	id int primary key auto_increment,
	task varchar(1000),
	isdone bool
);

insert into task (task,isdone) values 
('test',false),
('test1',true),
('test2',false),
('test3',true),
('test4',false),
('test5',false),
('test6',true),
('test7',false),
('test8',true),
('test9',true);
