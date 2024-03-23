
```mermaid
---
title: Workspaces
---

erDiagram
    Workspaces |o--|| Members : ""
    Workspaces {
        Id uuid PK
        Name varchar
    }

    Members {
        Id uuid PK
        UserId int4
        WorkspaceId uuid FK
        Status MemberStatus
    }

    MemberStatus {
        Active Zero
        Disabled One
        Invited Two
    }
```