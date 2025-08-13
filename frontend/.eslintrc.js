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