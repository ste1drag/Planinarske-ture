import { Search } from 'lucide-react';
import { useTranslation } from '@/contexts/TranslationContext';

interface SearchBarProps {
  placeholder?: string;
  className?: string;
  inputClassName?: string;
  iconClassName?: string;
  containerClassName?: string;
  value?: string;
}

export default function SearchBar({
  placeholder = '',
  className = '',
  inputClassName = '',
  iconClassName = '',
  containerClassName = '',
}: SearchBarProps) {
  const t = useTranslation();
  return (
    <div className={`relative flex items-center p-3 ${containerClassName}`}>
      <div className={`relative w-full ${className}`}>
        <Search
          size={20}
          className={`absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 ${iconClassName}`}
        />
        <input
          type="text"
          placeholder={placeholder}
          className={`w-full text-sm pl-10 pr-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-forest-light focus:border-transparent ${inputClassName}`}
        />
      </div>
    </div>
  );
}
