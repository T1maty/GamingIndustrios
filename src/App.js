import {Routes, Route} from "react-router-dom";
import ItemDescription from "./myComponents/ItemDescription";
import Top from './myComponents/Top'
import Slider from './myComponents/Slider'
import ItemGrid from "./myComponents/ItemGrid";
import image from './image'
import ItemSlider from "./myComponents/ItemSlider";



const imagesForSlider = [image.brain, image.smartphone, image.logo]

function App() {
  return (
    <Routes>
      <Route path="/" element={
        <div>
          <Top />
          <Slider value={imagesForSlider}/>
          <ItemGrid />
        </div>
      } />
      <Route path="/item" element={
        <div>
          <Top />
          <ItemDescription />
          <ItemSlider />
        </div>
      } />
    </Routes>
  );
}

export default App;
