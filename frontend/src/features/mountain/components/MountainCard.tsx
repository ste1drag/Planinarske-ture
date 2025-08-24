import { Calendar, Mountain, TrendingUp } from 'lucide-react';
import { MountainDto } from '../types/mountain-dto';
import { Card, CardContent, CardHeader } from '@/components/ui/Card';
import IconPrefixedText from '@/components/ui/IconPrefixedText';
import { useTranslation } from '@/contexts/TranslationContext';

export default function MountainCard({ mountain }: { mountain: MountainDto }) {
  const t = useTranslation();

  return (
    <Card className="w-full min-w-[30vw] max-w-[40vw] min-h-fit">
      <CardHeader>
        <IconPrefixedText
          icon={Mountain}
          text={mountain.name}
          textClassName="text-xl"
          gap="md"
          iconSize={22}
        />
        <hr />
      </CardHeader>
      <CardContent>
        <h1 className="text-xl text-black/40 pb-5">
          {mountain?.height && mountain.height + 'm'}
        </h1>
        <div className="flex justify-between pb-2">
          <IconPrefixedText
            icon={TrendingUp}
            text={t.totalHours}
            textClassName="text-xl"
            gap="md"
            iconSize={22}
          />
          TODO
        </div>
        <div className="flex justify-between b-2 ">
          <IconPrefixedText
            icon={Calendar}
            text={t.upcoming}
            textClassName="text-xl"
            gap="md"
            iconSize={22}
          />
          <text className="text-green-300">TODO</text>
        </div>
      </CardContent>
    </Card>
  );
}
