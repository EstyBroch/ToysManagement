import { Route,Routes } from "react-router-dom"
import ToysGrid from "./ToysGrid"
import Login from "./Login"

export default()=>{
   return( 
      <div>
<Routes>
    <Route path="/" element={<Login></Login>}/>
    <Route path="/toysGrid" element={<ToysGrid></ToysGrid>}/>
</Routes>
   </div>)
}