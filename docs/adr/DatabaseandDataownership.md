
# ADR-002: Database and Data Ownership

- Status: Proposed
- Date: 2026-11-13

## Context

Since we are using microservices, we need to decide how each service will store and access its data.

We want to keep the initial database infrastructure simple while ensuring that services do not depend directly on each other's data.

## Decision

We have decided to use PostgreSQL as our primary database and Entity Framework Core as the ORM.

Initially, we will use one PostgreSQL database with a single shared schema for all services.

Each microservice will have its own database account. We will provide access only to the tables that the particular service needs.

For example, the Order Service will have access to its order-related tables, while the Invoice Service will have access to its invoice-related tables.

Each service will be responsible for its own tables and database migrations.

A service should not directly access or modify tables owned by another service. If data from another service is required, we will obtain it through the appropriate API or events.

We will also follow these rules:

- Use decimal and PostgreSQL numeric types for monetary values.
- Keep database credentials outside source control.
- Apply only the required database permissions to each service account.
- Maintain database migrations as part of the service that owns the data.

## Alternatives Considered

- **Separate Schema for Every Service:** We considered this, but initially prefer a shared schema with restricted table-level permissions.
- **Separate Database Server for Every Service:** This can provide more isolation, but we do not need that additional infrastructure initially.
- **Unrestricted Shared Database Access:** We will not use this because it can make services tightly coupled.

## Consequences

- We can manage the initial database infrastructure easily.
- Each service has a clear data ownership boundary.
- Database access can be restricted using separate accounts and permissions.
- We need to carefully manage table permissions and naming.
- If the application grows, we can consider moving individual services to separate databases.
