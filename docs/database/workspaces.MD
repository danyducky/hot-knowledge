
```mermaid

---
title: Workspaces
---

erDiagram

    Workspaces ||--|{ Members : ""
    Workspaces {
        Id uuid PK
        Name varchar
    }

    Members {
        UserId int4 PK
        WorkspaceId uuid PK
        Status MemberStatus
    }

    MemberStatus {
        Active Zero
        Disabled One
        Invited Two
    }
```