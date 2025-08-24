import { LucideIcon } from 'lucide-react';
import React from 'react';
import { cn } from '@/lib/utils';

interface IconPrefixedTextProps {
  icon: LucideIcon;
  text: string;
  iconSize?: number;
  iconColor?: string;
  textColor?: string;
  gap?: 'sm' | 'md' | 'lg';
  className?: string;
  style?: React.CSSProperties;
}

const gapSizes = {
  sm: 'gap-1',
  md: 'gap-2',
  lg: 'gap-3',
};

export default function IconPrefixedText({
  icon: Icon,
  text,
  iconSize = 16,
  iconColor,
  textColor,
  gap = 'sm',
  className,
  style,
}: IconPrefixedTextProps) {
  return (
    <div
      className={cn('inline-flex items-center', gapSizes[gap], className)}
      style={style}
    >
      <Icon size={iconSize} color={iconColor} className="shrink-0" />
      <span style={{ color: textColor }} className="text-sm">
        {text}
      </span>
    </div>
  );
}
