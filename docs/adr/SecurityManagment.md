
# ADR-004: Security Management

- Status: Proposed
- Date: 2026-11-13

## Context

OrderSphere will be operated by our central business organization.

Our business will purchase products or components from different suppliers. We may combine products or components to create our own products and sell them to different buyer companies.

There will be three main types of organizations involved in the platform:

1. Our central operating organization.
2. Supplier organizations.
3. Buyer organizations.

Since different organizations will use the same platform, we need to control what information each organization and its users can access.

For example, one supplier should not be able to see another supplier's pricing or orders. Similarly, one buyer should not be able to access another buyer's invoices or payment information.

## Decision

We will maintain organization information and relationships within the application.

Users will be associated with organizations and assigned appropriate roles and permissions.

Access to application data will depend on the user's organization, role, and the business operation being performed.

The main organization types will be:

- **Operating Organization:** Manages the overall business, supplier relationships, products, orders, and sales.
- **Supplier Organization:** Provides products or components to the operating organization.
- **Buyer Organization:** Purchases products from the operating organization.

We will enforce access restrictions at the backend API and service levels. We will not rely only on frontend restrictions.

We will also ensure that organization-specific data is accessed only by authorized users.

## Alternatives Considered

- **No Organization-Level Access Control:** We decided against this because suppliers and buyers must not have access to each other's confidential information.
- **Separate Application for Every Organization:** We do not need separate application deployments for every supplier or buyer in the initial business model.
- **Frontend-Only Access Restrictions:** We will not rely on this because backend authorization is necessary to protect business data.

## Consequences

- We can manage multiple suppliers and buyers through one platform.
- Each organization will have controlled access to its information.
- We can manage different user roles and permissions.
- We will need to maintain organization relationships and authorization rules carefully.
- We can extend the organization model in the future if the business model changes.
