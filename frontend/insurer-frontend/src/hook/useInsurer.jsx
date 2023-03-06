import { useContext } from "react"
import InsurerContext from "../Context/InsurerProvider"

const useInsurer = () => useContext(InsurerContext); 
export default useInsurer; 