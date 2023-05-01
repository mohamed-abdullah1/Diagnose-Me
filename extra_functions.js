const handleDate = (date_arg) => {
  const [date, time] = date_arg.split('T');
  const [year, month, day] = date.split(/[-,\/]/);
  const [hour = 0, minute = 0, second = 0] = time?.split(':');
  second = second.substring(0, 2); // or use replace to replace Z with '' and leave milliseconds
  const args = [year, month - 1, day, hour, minute, second];
  return new Date(Date.UTC(...args));
};
