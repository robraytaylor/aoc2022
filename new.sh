echo $1

if [ $(pwd) != "/Users/rob/aoc2022" ]
then
    echo "PWD should be /Users/rob/aoc2022 exiting"
    exit
fi

mkdir "day$1"
cd "day$1"
dotnet new console

touch "test.txt"
touch "puzzle.txt"