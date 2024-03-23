```mermaid
---
title: Projects
---

erDiagram
    Projects |o--|| Statuses : ""
    Projects {
        Id uuid PK
        WorkspaceId uuid FK
        ClientId uuid FK
        StatusId int4 FK

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