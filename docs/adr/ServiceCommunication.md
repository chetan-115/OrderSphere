
# ADR-003: Service Communication

- Status: Proposed
- Date: 2026-11-13

## Context

Our application will contain multiple independent services. These services need to communicate with each other to complete business workflows.

For example, when an order is accepted, the fulfilment process may need to start. After delivery, the billing process may need to generate an invoice.

We need a communication approach that supports both immediate responses and background processing.

## Decision

We will use both synchronous and asynchronous communication.

For synchronous communication, we will use HTTP-based APIs when a service needs an immediate response from another service.

For asynchronous communication, we will use AWS SNS and SQS to exchange events and process background tasks.

We will follow these practices:

- Use the Transactional Outbox pattern to publish events reliably.
- Make message consumers idempotent so that duplicate messages do not cause duplicate business operations.
- Assume at-least-once message delivery.
- Use retry mechanisms for temporary failures.
- Configure dead-letter queues for messages that cannot be processed.
- Use correlation IDs and distributed tracing to track requests across services.
- Maintain versioned API and event contracts.

## Alternatives Considered

- **Only Synchronous Communication:** This can create dependencies between services and make the overall workflow more sensitive to failures.
- **Only Asynchronous Communication:** Some operations require an immediate response, so asynchronous communication alone is not sufficient.
- **Direct Database Communication:** We will avoid this because services should not access each other's internal data.

## Consequences

- We can use synchronous APIs for operations that require immediate responses.
- Background workflows can run independently.
- Services will be less dependent on each other's availability for asynchronous operations.
- We need to handle duplicate messages, retries, failures, and eventual consistency.
