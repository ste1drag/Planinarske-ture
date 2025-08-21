export interface InfoBoxProps {
  title: string;
  subTitle?: string;
  icon?: React.ReactElement;
}

export default function InfoBox({ title, subTitle, icon }: InfoBoxProps) {
  return (
    <div className="flex h-[10vh]  justify-between p-4">
      <div className="flex justify-center flex-col">
        <h1 className="text-3xl">{title}</h1>
        <h2 className="text-xl text-black/50">{subTitle}</h2>
      </div>
      <div className="flex items-start">{icon}</div>
    </div>
  );
}
