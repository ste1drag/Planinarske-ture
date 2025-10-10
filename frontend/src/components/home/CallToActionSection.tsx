import { Link } from 'react-router-dom';
import { Button } from '@/components/ui/Button';
import { useTranslation } from '@/contexts/TranslationContext';

const CallToActionSection = () => {
  const t = useTranslation();

  return (
    <section className="py-16 bg-gradient-to-r from-forest/10 to-mountain/10">
      <div className="container mx-auto px-4 text-center">
        <h2 className="text-3xl font-bold mb-4">{t.readyForAdventure}</h2>
        <p className="text-lg text-muted-foreground mb-8 max-w-2xl mx-auto">
          {t.joinCommunity}
        </p>
        <div className="flex flex-col sm:flex-row gap-4 justify-center">
          <Button asChild size="lg" className="bg-forest hover:bg-forest-dark">
            <Link to="/tours">{t.joinTour}</Link>
          </Button>
          <Button asChild variant="outline" size="lg">
            <Link to="/reviews">{t.readReviews}</Link>
          </Button>
        </div>
      </div>
    </section>
  );
};

export default CallToActionSection;
