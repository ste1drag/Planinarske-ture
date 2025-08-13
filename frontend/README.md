## Directory Structure

example:

```
src/
├── components/              # Shared UI components
│   ├── ui/                 # Basic components (Button, Input, Modal)
│   ├── layout/             # Layout components (Header, Sidebar, Footer)
│   ├── forms/              # Reusable form components
│   └── feedback/           # Loading, Error, Toast components
├── features/               # Feature-based modules
│   ├── tours/
│   │   ├── components/     # Feature-specific components
│   │   ├── hooks/          # Feature hooks
│   │   ├── api/            # Feature API calls
│   │   ├── types/          # Feature TypeScript types
│   │   ├── utils/          # Feature utilities
│   │   └── index.ts        # Feature exports
│   ├── auth/
│   ├── booking/
│   └── profile/
├── hooks/                  # Global custom hooks
├── lib/                    # Third-party configurations
│   ├── axios.ts
│   ├── queryClient.ts
│   └── router.tsx
├── pages/                  # Route components (thin wrappers)
├── stores/                 # Global state management
├── types/                  # Global TypeScript definitions
├── utils/                  # Global utilities
├── constants/              # App constants
└── assets/                 # Static assets
```
