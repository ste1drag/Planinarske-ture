import { createContext, useContext, ReactNode } from 'react';
import { en, Dictionary } from '@/dictionaries/en';

const TranslationContext = createContext<Dictionary>(en);

export const TranslationProvider = ({ children }: { children: ReactNode }) => (
  <TranslationContext.Provider value={en}>
    {children}
  </TranslationContext.Provider>
);

export const useTranslation = () => useContext(TranslationContext);
