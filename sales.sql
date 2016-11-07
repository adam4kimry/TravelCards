--написать запрос, который выводит продукт и кол-во случаев,
--когда он был первой покупкой клиента
declare @sales table (id int, productid int, customerid int, datecreated datetime)

--test
insert into @sales (id,productid,customerid,datecreated) values(1,111,1111,'01.01.2016 00:00')
insert into @sales (id,productid,customerid,datecreated) values(2,222,1111,'01.01.2016 00:01')
insert into @sales (id,productid,customerid,datecreated) values(3,222,2222,'02.01.2016 00:00')
insert into @sales (id,productid,customerid,datecreated) values(4,111,2222,'02.01.2016 00:01')
insert into @sales (id,productid,customerid,datecreated) values(5,333,2222,'02.01.2016 00:02')
insert into @sales (id,productid,customerid,datecreated) values(6,222,3333,'03.01.2016 00:00')
insert into @sales (id,productid,customerid,datecreated) values(7,111,3333,'03.01.2016 00:01')

--select * from @sales

--result
select
	s.productid,
	isnull([count],0) as [count]
from
	@sales s
	left outer join (
select
	productid,
	count(products.customerid) as [count]
from
	@sales products
	inner join (select
					customerid,
					min(datecreated) as datecreated
				from
					@sales
				group by
					customerid) customers on
		products.customerid = customers.customerid
where
	products.datecreated = customers.datecreated
group by
	productid
) t on s.productid = t.productid
group by
	s.productid,t.[count]