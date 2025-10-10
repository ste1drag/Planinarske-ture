import { Plus } from 'lucide-react';
import { useState } from 'react';
import { Button } from '../../../components/ui/Button';
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from '../../../components/ui/Dialog';
import { useTranslation } from '@/contexts/TranslationContext';

interface AddTourFormData {
  name: string;
  mountainId: string;
  description: string;
  minNumberOfPeople: string;
  maxNumberOfPeople: string;
  date: string;
}

export default function AddNewTourDialog() {
  const t = useTranslation();
  const [open, setOpen] = useState(false);
  const [formData, setFormData] = useState<AddTourFormData>({
    name: '',
    mountainId: '',
    description: '',
    minNumberOfPeople: '',
    maxNumberOfPeople: '',
    date: '',
  });

  const handleInputChange = (field: keyof AddTourFormData, value: string) => {
    setFormData(prev => ({
      ...prev,
      [field]: value,
    }));
  };

  const handleSave = () => {
    console.log('Saving tour:', formData);
    setOpen(false);
    setFormData({
      name: '',
      mountainId: '',
      description: '',
      minNumberOfPeople: '',
      maxNumberOfPeople: '',
      date: '',
    });
  };

  const handleCancel = () => {
    setOpen(false);
    setFormData({
      name: '',
      mountainId: '',
      description: '',
      minNumberOfPeople: '',
      maxNumberOfPeople: '',
      date: '',
    });
  };

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <button className="bg-forest-light text-white font-bold py-2 px-4 rounded flex items-center gap-2 hover:bg-forest transition-colors">
          <Plus size={16} />
          {t.addTourButton}
        </button>
      </DialogTrigger>
      <DialogContent className="flex flex-col bg-white border border-forest-light border-[3px] rounded-lg p-10 sm:max-w-[500px]">
        <DialogHeader className="flex items-center">
          <DialogTitle className="text-forest text-xl font-semibold">
            {t.addNewTour}
          </DialogTitle>
          <DialogDescription className="text-muted-foreground">
            Add a new tour to the system. Fill in all the details below.
          </DialogDescription>
          <hr className="border-t-2 my-6" />
        </DialogHeader>

        <div className="grid gap-4 py-4">
          <div className="grid gap-2">
            <label
              htmlFor="name"
              className="text-sm font-medium text-foreground"
            >
              {t.tourName}
            </label>
            <input
              id="name"
              type="text"
              placeholder={t.enterTourName}
              value={formData.name}
              onChange={e => handleInputChange('name', e.target.value)}
              className="flex h-9 w-full rounded-md border border-input bg-background px-3 py-1 text-sm shadow-sm transition-colors placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
            />
          </div>

          <div className="grid gap-2">
            <label
              htmlFor="mountainId"
              className="text-sm font-medium text-foreground"
            >
              {t.selectMountainForTour}
            </label>
            <select
              id="mountainId"
              value={formData.mountainId}
              onChange={e => handleInputChange('mountainId', e.target.value)}
              className="flex h-9 w-full rounded-md border border-input bg-background px-3 py-1 text-sm shadow-sm transition-colors placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
            >
              <option value="">{t.selectMountainForTour}</option>
              {/* TODO: Add dynamic mountain options */}
              <option value="mountain1">Sample Mountain 1</option>
              <option value="mountain2">Sample Mountain 2</option>
            </select>
          </div>

          <div className="grid gap-2">
            <label
              htmlFor="minNumberOfPeople"
              className="text-sm font-medium text-foreground"
            >
              {t.minPeople}
            </label>
            <input
              id="minNumberOfPeople"
              type="number"
              placeholder={t.enterMinPeople}
              value={formData.minNumberOfPeople}
              onChange={e =>
                handleInputChange('minNumberOfPeople', e.target.value)
              }
              className="flex h-9 w-full rounded-md border border-input bg-background px-3 py-1 text-sm shadow-sm transition-colors placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
            />
          </div>

          <div className="grid gap-2">
            <label
              htmlFor="maxNumberOfPeople"
              className="text-sm font-medium text-foreground"
            >
              {t.maxPeople}
            </label>
            <input
              id="maxNumberOfPeople"
              type="number"
              placeholder={t.enterMaxPeople}
              value={formData.maxNumberOfPeople}
              onChange={e =>
                handleInputChange('maxNumberOfPeople', e.target.value)
              }
              className="flex h-9 w-full rounded-md border border-input bg-background px-3 py-1 text-sm shadow-sm transition-colors placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
            />
          </div>

          <div className="grid gap-2">
            <label
              htmlFor="date"
              className="text-sm font-medium text-foreground"
            >
              {t.tourDate}
            </label>
            <input
              id="date"
              type="datetime-local"
              placeholder={t.selectTourDate}
              value={formData.date}
              onChange={e => handleInputChange('date', e.target.value)}
              className="flex h-9 w-full rounded-md border border-input bg-background px-3 py-1 text-sm shadow-sm transition-colors placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
            />
          </div>

          <div className="grid gap-2">
            <label
              htmlFor="description"
              className="text-sm font-medium text-foreground"
            >
              {t.tourDescription}
            </label>
            <textarea
              id="description"
              placeholder={t.enterTourDescription}
              value={formData.description}
              onChange={e => handleInputChange('description', e.target.value)}
              className="flex min-h-[80px] w-full rounded-md border border-input bg-background px-3 py-2 text-sm shadow-sm transition-colors placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50 resize-none"
              rows={3}
            />
          </div>
        </div>

        <DialogFooter className="flex gap-2">
          <Button variant="outline" onClick={handleCancel}>
            {t.cancel}
          </Button>
          <Button
            onClick={handleSave}
            className="bg-forest text-white hover:bg-forest-dark"
          >
            {t.save}
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
}
