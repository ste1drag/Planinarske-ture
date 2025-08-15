import { ArrowRight } from 'lucide-react';
import { Link } from 'react-router-dom';
import heroImage from '../assets/hero-mountain.jpg';
import { Button } from '../components/ui/button';
import { useTranslation } from '../contexts/TranslationContext';

const Home = () => {
  const t = useTranslation();

  return (
    <div className="min-h-screen bg-background">
      <section
        className="relative h-[600px] bg-cover bg-center bg-no-repeat"
        style={{ backgroundImage: `url(${heroImage})` }}
      >
        <div className="absolute inset-0 bg-gradient-to-t from-black/70 via-black/30 to-black/10" />
        <div className="relative container mx-auto px-4 h-full flex items-center">
          <div className="max-w-2xl text-white">
            <h1 className="text-5xl md:text-6xl font-bold mb-6 leading-tight">
              {t.heroTitle}
              <span className="block bg-gradient-to-r from-forest-light to-sky bg-clip-text text-transparent">
                {t.heroTitleGradient}
              </span>
            </h1>
            <p className="text-xl mb-8 text-white/90 leading-relaxed">
              {t.heroSubtitle}
            </p>
            <div className="flex flex-col sm:flex-row gap-4">
              <Button
                asChild
                size="lg"
                className="bg-forest hover:bg-forest-dark text-lg px-8"
              >
                <Link to="/tours">
                  {t.exploreTours}
                  <ArrowRight className="ml-2 h-5 w-5" />
                </Link>
              </Button>
              <Button
                asChild
                variant="outline"
                size="lg"
                className="text-lg px-8 bg-white/10 border-white/30 text-white hover:bg-white/20"
              >
                <Link to="/mountains">{t.viewMountains}</Link>
              </Button>
            </div>
          </div>
        </div>
      </section>

      <section className="py-16 bg-gradient-to-r from-forest/10 to-mountain/10">
        <div className="container mx-auto px-4 text-center">
          <h2 className="text-3xl font-bold mb-4">{t.readyForAdventure}</h2>
          <p className="text-lg text-muted-foreground mb-8 max-w-2xl mx-auto">
            {t.joinCommunity}
          </p>
          <div className="flex flex-col sm:flex-row gap-4 justify-center">
            <Button
              asChild
              size="lg"
              className="bg-forest hover:bg-forest-dark"
            >
              <Link to="/tours">{t.joinTour}</Link>
            </Button>
            <Button asChild variant="outline" size="lg">
              <Link to="/reviews">{t.readReviews}</Link>
            </Button>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Home;
