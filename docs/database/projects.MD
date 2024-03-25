```mermaid
---
title: Projects
---

erDiagram
    Projects |o--|| Statuses : ""
    Projects {
        Id uuid PK
        WorkspaceId uuid
        ClientId uuid
        StatusId int4 FK
        CreatedByUserId int4

        Name varchar
        Shortcut varchar
        Importance decimal

        StartedAt date
        FinishedAt date
    }

    Statuses {
        Id int4
        Name varchar
    }
```