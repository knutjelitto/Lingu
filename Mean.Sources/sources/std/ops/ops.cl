pub trait Add<Rhs=Self, Output=Self>
{
    fn add(self, rhs: Rhs) -> Output;
}
