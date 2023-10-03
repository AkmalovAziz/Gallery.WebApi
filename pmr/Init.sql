create table users (
	id bigint generated always as identity primary key,
	first_name varchar(20),
	last_name varchar(20),
	email text,
	password_hash text,
	salt text,
	description text,
	created_at timestamp without time zone,
	updated_at timestamp without time zone
);

create table images (
	id bigint generated always as identity primary key,
	user_id bigint references users(id) not null,
	name text,
	created_at timestamp without time zone,
	updated_at timestamp without time zone
);