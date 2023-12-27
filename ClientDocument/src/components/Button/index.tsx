import { ButtonArea, ButtonContainer } from "./style";

export interface Button {
  name: string;
}

function Button(props: Button) {
  return (
    <ButtonContainer>
      {props.name}
      <ButtonArea name={props.name} />
    </ButtonContainer>
  );
}

export default Button;
