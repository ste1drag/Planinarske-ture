import { createContext, useContext, ReactNode, useState } from 'react';
import { en, Dictionary } from '@/dictionaries/en';
import { srb } from '@/dictionaries/srb';

const TranslationContext = createContext<Dictionary>(srb);

export const TranslationProvider = ({ children }: { children: ReactNode }) => {
  const [lang, setLang] = useState<'srb' | 'en'>('srb');
  const dictionaries = { en, srb };

  return (
    <TranslationContext.Provider value={dictionaries[lang]}>
      <select
        value={lang}
        onChange={e => setLang(e.target.value as 'en' | 'srb')}
      >
        <option value="en">English</option>
        <option value="srb">Srpski</option>
      </select>
      {children}
    </TranslationContext.Provider>
  );
};

export const useTranslation = () => useContext(TranslationContext);
