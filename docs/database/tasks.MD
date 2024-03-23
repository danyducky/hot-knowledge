```mermaid
---
title: Tasks
---

erDiagram
    Tasks {
        Id uuid PK
        AssigneeUserId int
        CreatedByUserId int

        ProjectId uuid

        Number int
        Summary text
        Shortcut varchar

        CreatedAt timestamp
        UpdatedAt timestamp
    }
```