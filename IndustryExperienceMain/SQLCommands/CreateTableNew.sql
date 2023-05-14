DROP TABLE job;
DROP TABLE agency;

CREATE TABLE agency (
    agency_id               NUMERIC(5) NOT NULL,
    agency_name             VARCHAR(500) NOT NULL,
    link                    VARCHAR(500) NOT NULL,
    logo_link               VARCHAR(500) NOT NULL
);

ALTER TABLE agency ADD CONSTRAINT agency_pk PRIMARY KEY ( agency_id );

CREATE TABLE job (
    job_id               NUMERIC(5) NOT NULL,
    agency_id                  NUMERIC(5) NOT NULL,
    type_of_work             VARCHAR(50) NOT NULL,
    commitment               VARCHAR(500) NOT NULL,
    time_section             VARCHAR(500) NOT NULL,
    workplace                VARCHAR(500) NOT NULL,
	Link					VARCHAR(500) NOT NULL
);

ALTER TABLE job ADD CONSTRAINT job_pk PRIMARY KEY ( job_id );
ALTER TABLE job
    ADD CONSTRAINT job_id_fk1 FOREIGN KEY (agency_id)
        REFERENCES agency (agency_id)