
# ADR-001: Microservices Architecture

- Status: Proposed
- Date: 2026-11-13

## Context

OrderSphere is a B2B Order-to-Cash platform. Our business will purchase products or components from different suppliers, combine them where required, and sell the final products to other companies.

As the platform grows, different parts of the application will have different responsibilities and requirements. We want to keep these parts independent so that changes in one area do not unnecessarily affect the others.

## Decision

We have decided to use a microservices architecture from the beginning.

We will identify services based on the actual use cases and responsibilities of the application. We will not create a separate service for every business entity or table.

Each service should have its own responsibility and should be independently deployable. Services should communicate through APIs or events instead of depending on each other's internal implementation.

Initially, all services will use the same PostgreSQL database and schema. However, each service will have its own database account and access will be restricted to the tables required by that service.

## Alternatives Considered

- **Monolithic Architecture:** We considered starting with a single application, but we prefer independent services from the beginning.
- **One Service for Every Business Entity:** We decided against this because it can create too many small services and unnecessary communication.
- **Separate Database Server for Every Service:** We may consider this in the future, but initially we will use one PostgreSQL database server.

## Consequences

- Services can be developed and deployed independently.
- Changes in one service should have minimal impact on other services.
- Each service will have clear responsibilities.
- We will need to handle service communication, failures, monitoring, and deployment separately.
- We must maintain clear database ownership to avoid tight coupling.
