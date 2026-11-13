
create table os.os_organizations (
    id uuid primary key default gen_random_uuid(),
    name varchar(150) not null,
    ozcode varchar(50) not null unique,
    oztype char(1) not null,
    legal_name varchar(200) not null,
    tax_registration_number varchar(100),
    email varchar(320) not null,
    phone_number varchar(20),
    website varchar(255),
    status char(1) not null default 'A',
    created_at_utc timestamptz not null default now(),
    updated_at_utc timestamptz,
    constraint ck_organizations_name check (length(trim(name)) > 0),
    constraint ck_organizations_ozcode check (length(trim(ozcode)) > 0),
    constraint ck_organizations_oztype check (oztype in ('O', 'S', 'B')),
    constraint ck_organizations_legal_name check (length(trim(legal_name)) > 0),
    constraint ck_organizations_email check (length(trim(email)) > 0),
    constraint ck_organizations_status check (status in ('A', 'I', 'S'))
);


create table os.organization_addresses (
    id uuid primary key default gen_random_uuid(),
    organization_id uuid not null references os.os_organizations(id) on delete restrict,
    address_line1 varchar(200) not null,
    address_line2 varchar(200),
    city varchar(100) not null,
    state varchar(100),
    postal_code varchar(20) not null,
    country_code char(2) not null,
    address_type char(1) not null,
    is_primary boolean not null default false,
    constraint ck_address_line1 check (length(trim(address_line1)) > 0),
    constraint ck_address_city check (length(trim(city)) > 0),
    constraint ck_address_postal_code check (length(trim(postal_code)) > 0),
    constraint ck_address_country_code check (country_code ~ '^[A-Z]{2}$'),
    constraint ck_address_type check (address_type in ('B', 'S'))
);

create table os.organization_contacts (
    id uuid primary key default gen_random_uuid(),
    organization_id uuid not null references os.os_organizations(id) on delete restrict,
    first_name varchar(100) not null,
    last_name varchar(100) not null,
    email varchar(350) not null,
    phone_number varchar(20),
    designation varchar(100),
    is_primary boolean not null default false,
    constraint ck_contact_first_name check (length(trim(first_name)) > 0),
    constraint ck_contact_last_name check (length(trim(last_name)) > 0),
    constraint ck_contact_email check (length(trim(email)) > 0)
);