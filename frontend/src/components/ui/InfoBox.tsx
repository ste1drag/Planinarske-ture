export interface InfoBoxProps {
  title: string;
  subTitle?: string;
  icon?: React.ReactElement;
}

export default function InfoBox({ title, subTitle, icon }: InfoBoxProps) {
  return (
    <div className="flex flex-1 m-[1vh] h-[10vh] justify-between p-4 border border-gray-200 rounded shadow-lg">
      <div className="flex justify-center flex-col">
        <h1 className="text-xl">{title}</h1>
        <h2 className="text text-black/50">{subTitle}</h2>
      </div>
      <div className="flex items-baseline pt-[1vh]">{icon}</div>
    </div>
  );
}
