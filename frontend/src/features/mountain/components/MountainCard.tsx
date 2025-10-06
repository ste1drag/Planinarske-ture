import { Mountain } from 'lucide-react';
import { ViewMountainDto } from '../types/ViewMountainDto';
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/Card';

export default function MountainCard({
  mountain,
}: {
  mountain: ViewMountainDto;
}) {
  return (
    <Card className="w-full max-w-sm hover:shadow-lg transition-shadow">
      <CardHeader>
        <CardTitle className="flex items-center gap-2 text-forest">
          <Mountain className="h-5 w-5" />
          {mountain.name}
        </CardTitle>
      </CardHeader>
      <CardContent>
        <p className="text-2xl font-bold text-muted-foreground">
          {mountain.height}m
        </p>
      </CardContent>
    </Card>
  );
}
