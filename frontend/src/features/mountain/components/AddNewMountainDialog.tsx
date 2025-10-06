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

interface AddMountainFormData {
  name: string;
  description: string;
  height: string;
  location: string;
}

export default function AddNewMountainDialog() {
  const t = useTranslation();
  const [open, setOpen] = useState(false);
  const [formData, setFormData] = useState<AddMountainFormData>({
    name: '',
    description: '',
    height: '',
    location: '',
  });

  const handleInputChange = (
    field: keyof AddMountainFormData,
    value: string
  ) => {
    setFormData(prev => ({
      ...prev,
      [field]: value,
    }));
  };

  const handleSave = () => {
    console.log('Saving mountain:', formData);
    setOpen(false);
    setFormData({
      name: '',
      description: '',
      height: '',
      location: '',
    });
  };

  const handleCancel = () => {
    setOpen(false);
    setFormData({
      name: '',
      description: '',
      height: '',
      location: '',
    });
  };

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <button className="bg-forest-light text-white font-bold py-2 px-4 rounded flex items-center gap-2 hover:bg-forest transition-colors">
          <Plus size={16} />
          {t.addMountainButton}
        </button>
      </DialogTrigger>
      <DialogContent className="flex flex-col bg-white border border-forest-light border-[3px] rounded-lg p-10 sm:max-w-[500px]">
        <DialogHeader className="flex items-center">
          <DialogTitle className="text-forest text-xl font-semibold">
            {t.addNewMountain}
          </DialogTitle>
          <DialogDescription className="text-muted-foreground">
            Add a new mountain to the system. Fill in all the details below.
          </DialogDescription>
          <hr className="border-t-2 my-6" />
        </DialogHeader>

        <div className="grid gap-4 py-4">
          <div className="grid gap-2">
            <label
              htmlFor="name"
              className="text-sm font-medium text-foreground"
            >
              {t.mountainName}
            </label>
            <input
              id="name"
              type="text"
              placeholder={t.enterMountainName}
              value={formData.name}
              onChange={e => handleInputChange('name', e.target.value)}
              className="flex h-9 w-full rounded-md border border-input bg-background px-3 py-1 text-sm shadow-sm transition-colors placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
            />
          </div>

          <div className="grid gap-2">
            <label
              htmlFor="location"
              className="text-sm font-medium text-foreground"
            >
              {t.mountainLocation}
            </label>
            <input
              id="location"
              type="text"
              placeholder={t.enterMountainLocation}
              value={formData.location}
              onChange={e => handleInputChange('location', e.target.value)}
              className="flex h-9 w-full rounded-md border border-input bg-background px-3 py-1 text-sm shadow-sm transition-colors placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
            />
          </div>

          <div className="grid gap-2">
            <label
              htmlFor="height"
              className="text-sm font-medium text-foreground"
            >
              {t.mountainHeight}
            </label>
            <input
              id="height"
              type="number"
              placeholder={t.enterMountainHeight}
              value={formData.height}
              onChange={e => handleInputChange('height', e.target.value)}
              className="flex h-9 w-full rounded-md border border-input bg-background px-3 py-1 text-sm shadow-sm transition-colors placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
            />
          </div>
          <div className="grid gap-2">
            <label
              htmlFor="description"
              className="text-sm font-medium text-foreground"
            >
              {t.mountainDescription}
            </label>
            <textarea
              id="description"
              placeholder={t.enterMountainDescription}
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
