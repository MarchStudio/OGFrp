cd ~/projects/OGFrp.Darwin
mkdir ./build
cp ./OGFrp.Darwin/OGFrp.Darwin/* ./build
cp ./OGFrp.Unix.Common/* ./build
cd ./build
g++ ./main.cpp -o ./OGFrp.Darwin.out
echo Over