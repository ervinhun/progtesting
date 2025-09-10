drop schema if exists petshop cascade;
create schema if not exists petshop;
create table petshop.seller (
                                id text primary key not null,
                                name text not null,
                                address text
);
create table petshop.pet (
                             id text primary key not null,
                             name text not null,
                             breed text,
                             createdAt timestamp with time zone not null,
                             sold_date date default null,
                             price numeric,
                             seller text references petshop.seller(id)
);