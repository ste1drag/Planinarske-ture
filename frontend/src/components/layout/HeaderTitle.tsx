interface HeaderTitleProps {
  title: string;
  subTitle?: string;
  button?: React.ReactNode;
}

export default function HeaderTitle({
  title,
  subTitle,
  button,
}: HeaderTitleProps) {
  return (
    <div className="flex h-[10vh] bg-forest/10 justify-between p-4 w-screen">
      <div className="flex justify-center flex-col">
        <h1 className="text-3xl">{title}</h1>
        <h2 className="text-xl text-black/50">{subTitle}</h2>
      </div>
      <div className="flex items-center">{button}</div>
    </div>
  );
}
