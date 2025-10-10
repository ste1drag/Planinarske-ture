import { LucideIcon } from 'lucide-react';
import React from 'react';
import { Badge } from './BaseBadge';

interface GenericBadgeProps<T extends string | number> {
  value: T;
  label: string;
  colorMap: Record<T, string>;
  iconMap?: Record<T, LucideIcon>;
  style?: React.CSSProperties;
}

export default function GenericBadge<T extends string | number>({
  value,
  label,
  colorMap,
  iconMap,
  style,
}: GenericBadgeProps<T>) {
  const color = colorMap?.[value];
  const IconComponent = iconMap?.[value];

  return (
    <Badge variant="outline" style={style}>
      {IconComponent && React.createElement(IconComponent, { color })}
      {label}
    </Badge>
  );
}
