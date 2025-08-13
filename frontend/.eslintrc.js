module.exports = {
  env: {
    browser: true,
    es2021: true,
    node: true,
  },
  extends: [
    'eslint:recommended',
    'plugin:@typescript-eslint/recommended',
    'plugin:react/recommended',
    'plugin:react-hooks/recommended',
    'plugin:prettier/recommended',
  ],
  parser: '@typescript-eslint/parser',
  parserOptions: {
    ecmaFeatures: {
      jsx: true,
    },
    ecmaVersion: 'latest',
    sourceType: 'module',
    project: './tsconfig.json',
  },
  plugins: [
    'react',
    '@typescript-eslint',
    'react-hooks',
    'import',
  ],
  rules: {
    'react/react-in-jsx-scope': 'off', // Not needed in React 17+
    '@typescript-eslint/no-unused-vars': 'error',
    '@typescript-eslint/prefer-optional-chain': 'error', // Use obj?.prop instead of obj && obj.prop
    '@typescript-eslint/prefer-nullish-coalescing': 'error', // Use value ?? 'default' instead of value || 'default'
    'prefer-const': 'error',
    'import/order': [
      'error',
      {
        groups: [
          'builtin',   // Node built-ins (fs, path)
          'external',  // npm packages (react, axios)
          'internal',  // Your absolute imports
          ['parent', 'sibling'], // Relative imports (../, ./)
          'index',     // ./index imports
        ],
        'newlines-between': 'never',
        alphabetize: { order: 'asc', caseInsensitive: true },
      },
    ],
  },
  settings: {
    react: {
      version: 'detect',
    },
  },
};